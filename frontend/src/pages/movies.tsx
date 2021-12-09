import { NextPage } from "next";
import { Grid, Box, Flex, Button, Text, useDisclosure } from "@chakra-ui/react";
import { MovieCard } from "../components/MovieCard";
import { useEffect, useState } from "react";
import { api } from "../services/api";
import { ModalCreateMovie } from "../components/Modal/ModalCreateMovie";
import { Header } from "../components/Header";

interface Movie {
    id: number;
    title: string;
    image: string;
    description: string;
    duration: string;
}

const movies: NextPage = () => {
    const { onOpen, onClose, isOpen } = useDisclosure();
    const [movies, setMovies] = useState<Movie[]>([]);

    const handleOpenAddMovieModal = () => {
        onOpen();
    }

    useEffect(() => {
        const getMovies = async () => {
            try {
                const { data } = await api.get<Movie[]>("/movies");
                console.log(data);

                setMovies([...movies, ...data])
            } catch (err) {
                console.log("FFFFFFFFFFFFFFFFFF");

            }
        }

        getMovies();
    }, []);

    return (
        <>
        <Header />
        <Box
            maxW="1200px"
            mx="auto"
            px="2%"
            mt="50px"
        >
            <Button
                colorScheme="purple"
                variant="outline"
                borderRadius="50%"
                w="80px"
                h="80px"
                onClick={handleOpenAddMovieModal}
            >
                <Text 
                    textAlign="center"
                    lineHeight="80px"
                    fontSize="70px">
                    +
                </Text>
            </Button>
            <Grid
                mt="20px"
                templateColumns={{ base: "1fr", md: "repeat(2, 1fr)", lg: "repeat(3, 1fr)" }}
                gap="10px"
                fontWeight="lighter"
                py="2rem"
            >
                {movies.length == 0 ? (
                    <Text> No movies created </Text>
                ): movies.map(movie => (
                    <MovieCard 
                        key={movie.id} 
                        image={movie.image}
                        id={movie.id}
                        description={movie.description}
                        duration={movie.duration}
                        title={movie.title}
                    />
                ))}
            </Grid>
            <ModalCreateMovie 
                isOpen={isOpen}
                onClose={onClose}
            />
        </Box>
        </>
    )
}

export default movies;
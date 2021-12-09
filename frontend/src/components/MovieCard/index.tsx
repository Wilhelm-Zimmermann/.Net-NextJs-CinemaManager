import { Box, Flex, Text, Img, useDisclosure } from "@chakra-ui/react";
import { ModalEditMovie } from "../Modal/ModalEditMovie";

interface MovieCardProps {
    description: string;
    duration: string;
    id: number;
    image: string;
    title: string;
}

export const MovieCard = ({ description, duration, id, image, title }: MovieCardProps) => {
    const { onOpen, isOpen, onClose } = useDisclosure();
    
    const handleOpenEditModal = () => {
        onOpen();
    }

    const [hour, minute, second] = duration.split(":");

    return (
        <Box
            w="100%"
            bg="gray.700"
            borderRadius="10px"
            minH="400px"
            cursor="pointer"
            transition="outline 400ms"
            _hover={{
                outline: "3px solid #805AD5"
            }}
            onClick={handleOpenEditModal}
        >
            <Img 
                borderTopRadius="10px"
                h="200px"
                src={`https://localhost:7156/movies/image/${image}`} w="100%"
            />
            <Box>
                <Text mt="5px" px="3%" fontSize="30px">{title}</Text>
                <Text 
                    px="3%"
                    py="2rem" 
                    fontSize="18px"
                    noOfLines={2}
                >{description}</Text>
            </Box>
            <Box px="1rem">
                <Text>Duração: {hour}:{minute}:{second}</Text>
            </Box>
            <ModalEditMovie
                id={id}
                movieDescription={description}
                movieTitle={title}
                movieHour={hour}
                movieMinute={minute}
                movieSecond={second}
                isOpen={isOpen}
                onClose={onClose}
            />
        </Box>
    );
}
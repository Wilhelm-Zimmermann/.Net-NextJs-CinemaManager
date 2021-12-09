import { 
    Modal,
    ModalOverlay, 
    ModalContent, 
    ModalHeader, 
    ModalBody, 
    ModalCloseButton, 
    useToast,
    Input,
    HStack,
    Text,
    Box,
    Button,
    FormLabel,
    Icon,
    Textarea } from '@chakra-ui/react';
import { FormEvent, FormEventHandler, useState } from 'react';
import { FaPlus } from "react-icons/fa";
import { api } from '../../services/api';

interface ModalEditMovieProps {
    id: number;
    movieTitle: string;
    movieDescription: string;
    movieHour: string;
    movieMinute: string;
    movieSecond: string;
    isOpen: boolean;
    onClose: () => void;
}

export function ModalEditMovie({ 
    isOpen, 
    id, 
    onClose,
    movieTitle,
    movieDescription,
    movieHour,
    movieMinute,
    movieSecond}: ModalEditMovieProps): JSX.Element {
    const [ title, setTitle ] = useState(movieTitle);
    const [ description, setDescription ] = useState(movieDescription);
    const [ hour, setHour ] = useState(movieHour);
    const [ minute, setMinute ] = useState(movieMinute);
    const [ second, setSecond ] = useState(movieSecond);
    const [ image, setImage ] = useState<File>();
    
    const toast = useToast();

    const handleCloseModal = (): void => {
        onClose();
    };

    const handleCancelEditMovie = ():void => {
        setTitle("");
        setDescription("");
        setHour("");
        setMinute("");
        setSecond("");

        onClose();
    }

    const handleDeleteMovie = async () => {
        try {
            await api.delete(`/movies/${id}`);
            window.location.reload();
        } catch (err) {
            toast({
                status: "error",
                title:" Error on delete movie"
            })
        }
    }

    const handleSubmitEditMovie = async (e: FormEvent) => {
        e.preventDefault();

        let formData = new FormData();

        formData.append("title", title);
        formData.append("description", description);
        formData.append("hours", hour);
        formData.append("minutes", minute);
        formData.append("seconds", second);
        formData.append("image", image);

        await api.put(`/movies/${id}`, formData);

        window.location.reload();
    }

    return (
        <Modal isOpen={isOpen} onClose={handleCloseModal} isCentered size="4xl">
            <ModalOverlay />
            <ModalContent bgColor="gray.900">
                <ModalHeader fontSize="4xl" textAlign="center">Editar Filme</ModalHeader>
                <ModalCloseButton />
                <ModalBody px="2rem">
                    <Box as="form" py="2rem" onSubmit={handleSubmitEditMovie}>

                        <Input type="text" placeholder="Título" value={title} onChange={e => setTitle(e.target.value)}/>
                        <Textarea mt="10px" type="text" placeholder="Descrição" value={description} onChange={e => setDescription(e.target.value)} rows={10} resize="none"/>

                        <FormLabel mt="20px" textAlign="center" display="block" htmlFor="image">
                            <Text><Icon as={FaPlus} w="30px" h="30px"/></Text>
                            <Text>Add Image</Text>
                        </FormLabel>
                        <Input id="image" display="none" onChange={e => setImage(e.target.files[0])} type="file"/>

                        <Text mt="10px">Duração</Text>
                        <HStack mt="10px">
                            <Input type="number" value={hour} onChange={e => setHour(e.target.value)} placeholder="Horas"/>
                            <Input type="number" value={minute} onChange={e => setMinute(e.target.value)} placeholder="Minutos"/>
                            <Input type="number" value={second} onChange={e => setSecond(e.target.value)} placeholder="Segundos"/>
                        </HStack>

                        <HStack mt="10px">
                            <Button type="submit" colorScheme="green">Criar</Button>
                            <Button colorScheme="red" onClick={handleCancelEditMovie}>Cancelar</Button>
                            <Button colorScheme="red" onClick={handleDeleteMovie}>Deletar</Button>
                        </HStack>

                    </Box>
                </ModalBody>
            </ModalContent>
        </Modal>
    );
}

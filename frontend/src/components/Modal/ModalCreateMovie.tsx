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
import { useForm } from 'react-hook-form';
import { FaPlus } from "react-icons/fa";
import { api } from '../../services/api';

interface ModalCreateMovieProps {
    isOpen: boolean;
    onClose: () => void;
}

export function ModalCreateMovie({ isOpen, onClose }: ModalCreateMovieProps): JSX.Element {
    const [ title, setTitle ] = useState("");
    const [ description, setDescription ] = useState("");
    const [ hour, setHour ] = useState("");
    const [ minute, setMinute ] = useState("");
    const [ second, setSecond ] = useState("");
    const [ image, setImage ] = useState<File>();
    const [ errors, setErrors ] = useState([]);

    const handleCloseModal = (): void => {
        onClose();
    };

    const handleCancelCreateMovie = ():void => {
        setTitle("");
        setDescription("");
        setHour("");
        setMinute("");
        setSecond("");

        onClose();
    }

    const handleSubmitCreateMovie = async (e: FormEvent) => {
        e.preventDefault();

        let formData = new FormData();

        formData.append("title", title);
        formData.append("description", description);
        formData.append("hours", hour);
        formData.append("minutes", minute);
        formData.append("seconds", second);
        formData.append("image", image);

        await api.post("/movies", formData);
        window.location.reload();
    }

    return (
        <Modal isOpen={isOpen} onClose={handleCloseModal} isCentered size="4xl">
            <ModalOverlay />
            <ModalContent bgColor="gray.900">
                <ModalHeader fontSize="4xl" textAlign="center">Criar Filme</ModalHeader>
                <ModalCloseButton />
                <ModalBody px="2rem">
                    <Box as="form" py="2rem" onSubmit={handleSubmitCreateMovie}>

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
                            <Button colorScheme="red" onClick={handleCancelCreateMovie}>Cancelar</Button>
                        </HStack>

                    </Box>
                </ModalBody>
            </ModalContent>
        </Modal>
    );
}

import {
    Table,
    Thead,
    Tbody,
    Tr,
    Th,
    Td,
    Box,
    Text,
    Button,
    Flex,
    Icon,
    useDisclosure,
    useToast
  } from '@chakra-ui/react'
import { useEffect, useState } from 'react';
import { api } from '../../services/api';
import { formatDateWithHour } from '../../utils/DateFormat';
import { ModalCreateSession } from '../Modal/ModalCreateSession';
import { FaTrashAlt } from "react-icons/fa";

interface Session {
    id: number;
    movieId: number;
    roomId: number;
    start: string;
    end: string;
    ticketValue: number;
}

export const SessionsContainer = () => {
    const [ sessions, setSessions ] = useState<Session[]>([]);
    const { isOpen, onOpen, onClose } = useDisclosure();
    const toast = useToast();

    const handleOpenModal = () => {
        onOpen();
    }

    const handleDeleteSession = async (id: number) => {
        try {

            await api.delete(`/sessions/${id}`)
            window.location.reload();
        } catch (err) {
            useToast({
                status: "error",
                title: "Só é possível deletar sessões com mais de 10 dias restantes"
            })
        }
    }

    useEffect(() => {
        const getSessions = async () => {
            const {data} = await api.get<Session[]>("/sessions");
            
            setSessions([...data])  
        }
        getSessions();
    }, []);

    return (
        <Box 
            maxW="1100px"
            mx="auto"
            mt="100px"
            px="2rem"
            overflowX="auto"
        >
            <Flex justify="space-between">
                <Text fontSize="30px">Sessões Disponíveis</Text>
                <Button 
                    colorScheme="purple" 
                    variant="outline" 
                    borderRadius="50%" 
                    w="60px" 
                    h="60px"
                    onClick={handleOpenModal}
                > <Text fontSize="40px"> + </Text> </Button>
            </Flex>

            <Table colorScheme="purple" mt="20px" size="md">
                <Thead>
                    <Tr>
                        <Th color="gray.100">Iníio</Th>
                        <Th color="gray.100">Fim</Th>
                        <Th color="gray.100">Sala</Th>
                        <Th color="gray.100">Filme</Th>
                        <Th color="gray.100">Valor</Th>
                        <Th color="gray.100">Actions</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {sessions.map(session => (
                        <Tr key={session.id}>
                            <Td><Text color="gray.50">{formatDateWithHour(new Date(session.start))}</Text></Td>
                            <Td><Text color="gray.50">{formatDateWithHour(new Date(session.end))}</Text></Td>
                            <Td><Text color="gray.50">{session.roomId}</Text></Td>
                            <Td><Text color="gray.50">{session.movieId}</Text></Td>
                            <Td><Text color="gray.50">{session.ticketValue}</Text></Td>
                            <Td><Button colorScheme="red" onClick={() => handleDeleteSession(session.id)}><Icon as={FaTrashAlt}/></Button></Td>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
            <ModalCreateSession 
                onClose={onClose}
                isOpen={isOpen}
            />
        </Box>
    );
}


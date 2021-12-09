import {
    Table,
    Thead,
    Tbody,
    Tfoot,
    Tr,
    Th,
    Td,
    TableCaption,
    Box,
    Text
  } from '@chakra-ui/react'
import { useEffect, useState } from 'react';
import { api } from '../../services/api';

interface RoomsContainer {
    id: number;
    name: string;
    seatsQuantity: number;
}

export const RoomsContainer = () => {
    const [ rooms, setRooms ] = useState<RoomsContainer[]>([]);

    useEffect(() => {
        const getRooms = async () => {
            const {data} = await api.get<RoomsContainer[]>("/rooms");
            setRooms([...data])  
        }
        getRooms();
    }, []);
    return (
        <Box 
            maxW="1100px"
            mx="auto"
            mt="100px"
            px="2rem"
        >
            <Text fontSize="30px">Salas Disponíveis</Text>
            <Table colorScheme="purple" mt="20px" size="md">
                <Thead>
                    <Tr>
                        <Th color="gray.100">Name</Th>
                        <Th color="gray.100">Seats</Th>
                    </Tr>
                </Thead>
                <Tbody>
                    {rooms.map(room => (
                        <Tr key={room.id}>
                            <Th><Text color="gray.50">{room.name}</Text></Th>
                            <Th><Text color="gray.50">{room.seatsQuantity}</Text></Th>
                        </Tr>
                    ))}
                </Tbody>
            </Table>
        </Box>
    );
}
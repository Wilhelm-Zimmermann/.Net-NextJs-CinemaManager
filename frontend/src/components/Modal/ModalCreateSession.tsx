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
    Box,
    Button,
    Select,
    VStack
} from '@chakra-ui/react';
import { useEffect, useState } from 'react';
import { useForm } from 'react-hook-form';
import { api } from '../../services/api';

interface ModalCreateSessionProps {
    isOpen: boolean;
    onClose: () => void;
}
interface Room {
    id: number;
    name: string;
    seatsQuantity: number;
}

interface Movie {
    description: string;
    duration: string;
    id: number;
    image: string;
    title: string;
}
export function ModalCreateSession({ isOpen, onClose }: ModalCreateSessionProps): JSX.Element {
    const [start, setStart] = useState("");
    const [room, setRoom] = useState("");
    const [movie, setMovie] = useState("");
    const [ticketValue, setTicketValue] = useState("");
    const [rooms, setRooms] = useState<Room[]>([]);
    const [movies, setMovies] = useState<Movie[]>([]);

    const { formState, handleSubmit } = useForm();
    const { errors } = formState;
    const toast = useToast();
    
    useEffect(() => {
        const loadRoomsAndMovies = async () => {
            const { data: roomsData } = await api.get("/rooms");
            const { data: moviesData } = await api.get("/movies");
            
            setRooms([...roomsData]);
            setMovies([...moviesData]);
        }
        
        loadRoomsAndMovies();
    }, []);
    
        const handleSubmitCreateSession = async () => {
            
            console.log(errors);
            const data = {
                start,
                roomId: Number(room),
                movieId: Number(movie),
                ticketValue
            }
            try{

                await api.post("/sessions", data);
                window.location.reload();
            } catch (err) {
                toast({
                    status: 'error',
                    title: 'Sessão não criada',
                });
            }

        }

    return (
        <Modal isOpen={isOpen} onClose={onClose} isCentered size="4xl">
            <ModalOverlay />
            <ModalContent bgColor="gray.900">
                <ModalHeader fontSize="4xl" textAlign="center">Criar Sessão</ModalHeader>
                <ModalCloseButton />
                <ModalBody px="2rem">
                    <Box 
                        as="form" 
                        py="2rem" 
                        onSubmit={handleSubmit(handleSubmitCreateSession)}
                    >
                        <VStack spacing={3}>
                            <Input
                                type="text"
                                placeholder="Data e horário de início. MM/DD/AAAA HH:MM:SS"
                                value={start}
                                onChange={e => setStart(e.target.value)}
                            />

                            <Select bg="gray.800" onChange={e => setMovie(e.target.value)}>
                                <option selected={true} style={{ background: "#4A5568" }} disabled={true}>Movie</option>
                                {movies.map(movie => (
                                    <option key={movie.id} style={{ background: "#1A202C" }} value={movie.id}>{movie.title}</option>
                                ))}
                            </Select>

                            <Select bg="gray.800" onChange={e => setRoom(e.target.value)}>
                                <option selected={true} style={{ background: "#4A5568" }} disabled={true}>Room</option>
                                {rooms.map(room => (
                                    <option key={room.id} style={{ background: "#1A202C" }} value={room.id}>{room.name}</option>
                                ))}
                            </Select>

                            <Input type="number" placeholder="Ticket Value" value={ticketValue} onChange={e => setTicketValue(e.target.value)} />

                            <HStack mt="10px">
                                <Button 
                                    isLoading={formState.isSubmitting}
                                    isDisabled={formState.isSubmitting} 
                                    type="submit" 
                                    colorScheme="green"
                                >Criar</Button>
                            <Button colorScheme="red" onClick={onClose}>Cancelar</Button>
                        </HStack>
                    </VStack>
                </Box>
            </ModalBody>
        </ModalContent>
        </Modal >
    );
}

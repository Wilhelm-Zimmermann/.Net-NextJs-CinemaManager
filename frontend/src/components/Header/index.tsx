import { Box, Flex, Text, useDisclosure, Avatar, VStack,  DrawerOverlay, DrawerContent, DrawerBody, DrawerHeader, Drawer, DrawerCloseButton, useBreakpointValue  } from "@chakra-ui/react";
import Link from "next/link";
import { HeaderLink } from "./HeaderLink";
import { RiMovieLine } from "react-icons/ri";
import { FaDoorOpen } from "react-icons/fa";
import { IoMdTv } from "react-icons/io";

export const Header = () => {
    const { isOpen, onOpen, onClose } = useDisclosure();

    return (
        <Box w="100%" py="2rem" bg="gray.900">
        <Flex px="1rem" align="center">
        <Box border="0" cursor="pointer" onClick={onOpen}>
            <Text w="32px" h="4px" bg="white"></Text>
            <Text w="32px" mt="5px" h="4px" bg="white"></Text>
            <Text w="32px" mt="5px" h="4px" bg="white"></Text>
        </Box>
            <Drawer isOpen={isOpen} placement="left" onClose={onClose   }>
                <DrawerOverlay>
                    <DrawerContent bg="gray.800" p="4">
                        <DrawerCloseButton mt="6" />
                        <DrawerHeader> <Avatar src="https://localhost:7156/movies/image/profile.jpg" size="lg"/> <Text>ADM</Text> </DrawerHeader>
                        <DrawerBody>
                            <VStack spacing={3} align="left">
                                <HeaderLink icon={RiMovieLine} href="/movies" title="Movies" onClose={onClose}/>
                                <HeaderLink icon={FaDoorOpen} href="/rooms" title="Rooms" onClose={onClose}/>
                                <HeaderLink icon={IoMdTv} href="/sessions" title="Sessions" onClose={onClose}/>
                            </VStack>
                        </DrawerBody>
                    </DrawerContent>
                </DrawerOverlay>
            </Drawer>
            <Text textAlign="center" display="block" mx="auto" fontSize="30px">Cine Pop</Text>
        </Flex>
        </Box>
    )
}
import type { NextPage } from 'next';
import { FormControl, FormLabel, Input, Box, Flex, VStack, Button, Text } from "@chakra-ui/react";
import { useForm } from "react-hook-form";
import { FormEvent, useState } from 'react';
import { api } from '../services/api';
import { login } from '../services/auth';

const Home: NextPage = () => {
  const [ email, setEmail ] = useState("");
  const [ password, setPassword ] = useState("");

  const handleLogin = async (e: FormEvent) => {
    e.preventDefault()

    const bodyData = {
      email,
      password
    }

    const {data} = await api.post("/users/login", bodyData);
    
    login(data);

    window.location.href = "/movies"
  }

  const { register } = useForm();

  return (
    <Flex w="100%" h="100vh" align="center" justify="center">
    <Box 
      as="form" 
      bg="gray.700" 
      px="2rem" 
      py="2rem" 
      borderRadius="1rem" 
      w="700px" 
      mx="auto"
      onSubmit={handleLogin}
    >
    <Text fontSize="30px">Login</Text>
    <VStack mt="20px" spacing={3}>
      <FormControl id='email' isRequired>
        <FormLabel>Email address</FormLabel>
        <Input type='email' value={email} onChange={e => setEmail(e.target.value)}/>
      </FormControl>

      <FormControl id='password' isRequired>
        <FormLabel>Password</FormLabel>
        <Input type='password' value={password} onChange={e => setPassword(e.target.value)}/>
      </FormControl>

      <FormControl>
        <Button type="submit" w="180px" h="40px" colorScheme="green">Login</Button>
      </FormControl>
      </VStack>
    </Box>
    </Flex>
  )
}

export default Home;

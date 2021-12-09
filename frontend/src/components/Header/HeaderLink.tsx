import { Text, Icon, HStack } from "@chakra-ui/react";
import Link from "next/link";
import { ElementType } from "react";

interface HeaderLinkProps {
    onClose(): void;
    href: string;
    title: string;
    icon: ElementType;
}

export const HeaderLink = ({ onClose, title, href, icon }: HeaderLinkProps) => {
    return (
        <Link href={href}>
            <HStack spacing={3}>
                <Icon as={icon} w="30px" h="30px"/>
                <Text 
                    _hover={{color:"#9F7AEA"}} 
                    onClick={onClose} 
                    cursor="pointer" 
                    fontSize="20px"
                >
                    {title}
                </Text>
            </HStack>
        </Link>
    )
}
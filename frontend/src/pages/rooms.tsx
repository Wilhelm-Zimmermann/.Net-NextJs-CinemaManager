import { NextPage } from "next";
import { RoomsContainer } from "../components/RoomsContainer";
import { Header } from "../components/Header";



const Rooms: NextPage = () => {
    return (
        <>
        <Header />
        <RoomsContainer />
        </>
    )
}

export default Rooms;
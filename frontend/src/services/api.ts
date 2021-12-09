import axios from "axios";
import { getToken, logout } from "./auth";

export const api = axios.create({
    baseURL : "https://localhost:7156"
})

api.interceptors.request.use(
    async config => {
        const token = getToken();

        if(token) config.headers.Authorization = `Bearer ${token}`;
        
        return config;
    },

    err => {
        return Promise.reject(err);
    }
)

api.interceptors.response.use(

    response => {
        return response;
    },

    err => {
        if(err.response.status === 401) {
            logout()
        }

        return Promise.reject(err);
    }
)
import axios from 'axios'; 
import { API_BASE_URL } from './GetEnvVaribales';


const instance = axios.create({
    baseURL: API_BASE_URL, 
    timeout: 50000,
    headers:{
        'Content-Type':'application/json',
    } 
});

export default instance;
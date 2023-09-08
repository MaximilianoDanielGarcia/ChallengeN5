import axios from "axios";

export default axios.create({
    baseURL: 'https://localhost:7097/api/',
    headers: {
        "Content-type": "application/json"
    }
});
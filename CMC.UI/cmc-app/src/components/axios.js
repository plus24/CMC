import axios from 'axios';
const instance = axios.create({baseURL: 'https://localhost:7087'});
// const instance = axios.create({baseURL: 'https://621c7b01768a4e1020ab2bdd.mockapi.io'});

export default instance
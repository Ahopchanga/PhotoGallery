import axios from 'axios';

const apiUrl = '/auth';

export const register = (registrationRequest) => {
    return axios.post(`${apiUrl}/register`, registrationRequest);
}

export const login = (loginRequest) => {
    return axios.post(`${apiUrl}/login`, loginRequest);
}

export const logout = () => {
    return axios.post(`${apiUrl}/logout`);
}
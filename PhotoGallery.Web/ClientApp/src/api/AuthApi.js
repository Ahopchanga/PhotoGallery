import axios from 'axios';

export async function login(username, password) {
    const response = await axios.post('https://localhost:44421/login', {
        username: username,
        password: password
    });
    const token = response.data.token;
    localStorage.setItem('userToken', token);
    return token;
}
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { login } from '../api/AuthApi';

function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const onSubmit = async (event) => {
        event.preventDefault();
        const token = await login(username, password);
        if (token) {
            navigate('/albums');
        } else {
            alert('Failed to log in. Please try again.');
        }
    };

    return (
        <form onSubmit={onSubmit}>
            <label>
                Username:
                <input
                    type="text"
                    value={username}
                    onChange={e => setUsername(e.target.value)}
                    required
                />
            </label>
            <label>
                Password:
                <input
                    type="password"
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                    required
                />
            </label>
            <button type="submit">Log in</button>
        </form>
    );
}

export default Login;
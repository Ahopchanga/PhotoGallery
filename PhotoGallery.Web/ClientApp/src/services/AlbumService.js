import axios from 'axios';

const API_URL = 'endpointUrl';

export const fetchAlbums = async () => {
    try {
        const response = await axios.get(`${API_URL}/albums`);
        return response.data;
    } catch (error) {
        console.error('Failed to fetch albums', error);
        throw error;
    }
};

export const fetchAlbumById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/album/${id}`);
        return response.data;
    } catch (error) {
        console.error(`Failed to fetch album with id ${id}`, error);
        throw error;
    }
};

//TODO Similarly, implement other CRUD methods
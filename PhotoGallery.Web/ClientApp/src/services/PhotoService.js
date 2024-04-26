import axios from 'axios';

const API_URL = 'endpointUrl';

export const fetchPhotos = async () => {
    try {
        const response = await axios.get(`${API_URL}/photos`);
        return response.data;
    } catch (error) {
        console.error('Failed to fetch photos', error);
        throw error;
    }
};

export const fetchPhotoById = async (id) => {
    try {
        const response = await axios.get(`${API_URL}/photo/${id}`);
        return response.data;
    } catch (error) {
        console.error(`Failed to fetch photo with id ${id}`, error);
        throw error;
    }
};

export const addPhoto = async (photoData) => {
    try {
        const response = await axios.post(`${API_URL}/photos`, photoData);
        return response.data;
    } catch (error) {
        console.error(`Failed to add photo`, error);
        throw error;
    }
};

//TODO Similarly, implement other CRUD methods
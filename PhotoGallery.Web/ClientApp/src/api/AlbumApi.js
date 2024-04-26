import axios from 'axios';

const apiUrl = '/albums';

export const createAlbum = (album) => {
    return axios.post(`${apiUrl}`, album);
}

export const getAlbum = (id) => {
    return axios.get(`${apiUrl}/${id}`);
}

export const getAllAlbums = (pageNumber, pageSize) => {
    return axios.get(`${apiUrl}`, {
        params: {
            pageNumber: pageNumber,
            pageSize: pageSize,
        },
    });
}

export const deleteAlbum = (id) => {
    return axios.delete(`${apiUrl}/${id}`);
}

export const updateAlbum = (album) => {
    return axios.put(`${apiUrl}`, album);
}
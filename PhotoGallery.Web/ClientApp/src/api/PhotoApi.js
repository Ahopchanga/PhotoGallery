import axios from 'axios';

const apiUrl = '/photos';

export const addPhoto = (photo) => {
    return axios.post(`${apiUrl}`, photo);
}

export const getAllByAlbumId = (albumId) => {
    return axios.get(`${apiUrl}/album/${albumId}`);
}

export const deletePhoto = (id) => {
    return axios.delete(`${apiUrl}/${id}`);
}

export const updatePhoto = (photo) => {
    return axios.put(`${apiUrl}`, photo);
}

export const likePhoto = (photoId) => {
    return axios.post(`${apiUrl}/${photoId}/like`);
}

export const dislikePhoto = (photoId) => {
    return axios.post(`${apiUrl}/${photoId}/dislike`);
}
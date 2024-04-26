import axios from "axios";

export async function uploadPhoto(albumId, file) {
    const formData = new FormData();
    formData.append('file', file);
    const response = await axios.post(`https://localhost:44421/albums/${albumId}/photos`, formData, {
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    });
    return response.data;
}
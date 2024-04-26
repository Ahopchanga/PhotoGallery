import React, { useState } from "react";
import { uploadPhoto } from "../api/PhotoAlbumApi";

function PhotoUpload({ albumId }) {
    const [selectedFile, setSelectedFile] = useState();

    const onFileChange = event => {
        setSelectedFile(event.target.files[0]);
    };

    const onFileUpload = async () => {
        if (!selectedFile) {
            alert('Please select a file first');
            return;
        }
        await uploadPhoto(albumId, selectedFile);
    };

    return (
        <div>
            <input type="file" onChange={onFileChange} />
            <button onClick={onFileUpload}>Upload</button>
        </div>
    );
}
export default PhotoUpload;
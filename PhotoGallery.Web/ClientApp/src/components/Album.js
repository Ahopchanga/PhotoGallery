import React, { useEffect, useState } from "react";
import { getAlbum, deleteAlbum } from "../api/AlbumApi.js";

function Album({ match }) {
    const [album, setAlbum] = useState(null);

    useEffect(() => {
        getAlbum(match.params.id).then(response => {
            console.log(response);
            if (response && response.data) {
                setAlbum(response.data);
            }
        });
    }, [match.params.id]);

    const handleDelete = () => {
        deleteAlbum(album.id).then(() => {
        });
    }

    return (
        <div>
            {album && (
                <>
                    <h1>{album.title}</h1>
                    <button onClick={handleDelete}>Delete Album</button>
                </>
            )}
        </div>
    );
}

export default Album;
import React from 'react';

function Photo({ photo }) {
    const { id, title, url } = photo;

    return (
        <div className="photo">
            <img src={url} alt={title} />
            <p>{title}</p>
        </div>
    );
}

export default Photo;
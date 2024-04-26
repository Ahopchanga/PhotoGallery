import React from 'react';
import {BrowserRouter as Router, Routes, Route, Navigate} from 'react-router-dom';
import AlbumsTable from './pages/AlbumsTable';
import MyAlbums from './pages/MyAlbums';
import AlbumView from './pages/AlbumView';

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Navigate to="/albums" />} />
                <Route path='/albums' element={<AlbumsTable />} />
                <Route path='/my-albums' element={<MyAlbums />} />
                <Route path='/album/:id' element={<AlbumView />} />
                {/* TODO: Add NotFoundComponent for non-existing paths */}
            </Routes>
        </Router>
    );
}

export default App;
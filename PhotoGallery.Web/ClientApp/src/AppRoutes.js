import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Login from './pages/Login';
import AlbumsTable from './pages/AlbumsTable';
import MyAlbums from './pages/MyAlbums';
import AlbumView from './pages/AlbumView';

function App() {
  return (
      <Router>
        <Routes>
          <Route path="/login" element={<Login />} />
          <Route path="/albums" element={<AlbumsTable />} />
          <Route path="/my-albums" element={<MyAlbums />} />
          <Route path="/album-view/:id" element={<AlbumView />} />
        </Routes>
      </Router>
  );
}

export default App;
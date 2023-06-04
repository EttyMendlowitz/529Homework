import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Route, Routes } from 'react-router-dom';
import './App.css';
import Layout from './Layout';
import Home from './Home';
import Signup from './Signup';
import Login from './login'
import { AuthContextComponent } from './authContext';
import MyBookmarks from './myBookmarks';
import AddBookmark from './addBookmark';
import Logout from './logout';

const App = () => {
    return (
        <AuthContextComponent>
            <Layout>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/signup' element={<Signup />} />
                    <Route exact path='/login' element={<Login />} />
                    <Route exact path='/logout' element={<Logout />} />
                    <Route exact path='/addBookmark' element={<AddBookmark />} />
                    <Route exact path='/myBookmarks' element={<MyBookmarks/> }/>
                </Routes>
            </Layout>
        </AuthContextComponent>
)}

export default App;
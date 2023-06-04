import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { useAuth } from './authContext';
import axios from 'axios';

const MyBookmarks = () => {
    const [bookmarks, setBookmarks] = useState([]);
    const [title, setTitle] = useState();
    const [isEditing, setIsEditing] = useState([]);
    const { user } = useAuth();

    const getBookmarks = async () => {
        const { data } = await axios.get('/api/bookmarks/getbookmarks');
        setBookmarks(data);
    }
    useEffect(() => {
        getBookmarks();
    }, []);

    const onEditClick = (b) => {
        setIsEditing([...isEditing, b.id]);
        setTitle(b.title);
    }

    const onCancelClick = (id) => {
            setIsEditing(isEditing.filter(e => e != id));
    }

    const onDeleteClick = async(id) => {
        await axios.post('/api/bookmarks/deletebookmark', {id, user});
        await getBookmarks();
        setIsEditing(isEditing.filter(e => e != id));
    }

    const onUpdateClick = async (b) => {
        const { id } = b;
        await axios.post('/api/bookmarks/updatebookmark', {title, id, user });
        await getBookmarks();
        setIsEditing(isEditing.filter(e => e != id));
    }

    return (<div className="container" style={{ marginTop: 80 }}>
        <main role="main" className="pb-3">
            <div style={{ marginTop: 20 }}>
                <div className="row">
                    <div className="col-md-12">
                        <h1>Welcome back {user.firstName} {user.lastName}</h1>
                        <Link to='/addbookmark' className="btn btn-primary btn-block">
                            Add Bookmark
                        </Link>
                    </div>
                </div>
                <div className="row" style={{ marginTop: 20 }}>
                    <table className="table table-hover table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Title</th>
                                <th>Url</th>
                                <th>Edit/Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                            {bookmarks.map(b => {
                            return <tr key={b.id}>
                                <td>
                                    {isEditing.includes(b.id) && <input type="text" className="form-control" placeholder="Title" value={title} onChange={e => setTitle(e.target.value )} />}
                                    {!isEditing.includes(b.id) && b.title }
                                </td>
                                <td>
                                    <a href='{b.url}' target='_blank'>{b.url}</a>
                                </td>
                                <td>
                                    {isEditing.includes(b.id) &&
                                        <><button className="btn btn-warning" onClick={() => onUpdateClick(b)}>Update</button>
                                        <button className="btn btn-info" onClick={() => onCancelClick(b.id)}>Cancel</button> </>}
                                    {!isEditing.includes(b.id) && <button className="btn btn-success" onClick={() => onEditClick(b)}>Edit Title</button>}

                                    <button className="btn btn-danger" onClick={() => onDeleteClick(b.id)} style={{ marginLeft: '10px' }}>Delete</button>
                                </td>
                            </tr>
                        })}
                        </tbody>
                    </table>
                </div>
            </div>
        </main>
    </div>
    )
}

export default MyBookmarks;
import React, { useState } from 'react';
import { useAuth } from './authContext';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const AddBookmark = () => {

    const [url, setUrl] = useState('');
    const [title, setTitle] = useState('');
    const [isSubmitting, setIsSubmitting] = useState(false);
    const { user } = useAuth();
    const navigate = useNavigate();

    const onSubmit = async e => {
        setIsSubmitting(true);
        e.preventDefault();
        await axios.post('/api/bookmarks/addbookmark', { title, url, user});
        navigate('/myBookmarks')
        setIsSubmitting(false);
    }

    return (<div className="container" style={{ marginTop: 80 }}>
        <main role="main" className="pb-3">
            <div
                className="row"
                style={{ minHeight: "80vh", display: "flex", alignItems: "center" }}
            >
                <div className="col-md-6 offset-md-3 bg-light p-4 rounded shadow">
                    <h3>Add Bookmark</h3>
                    <form onSubmit={onSubmit }>
                        <input
                            type="text"
                            name="title"
                            placeholder="Title"
                            className="form-control"
                            onChange={e => setTitle(e.target.value )}
                            defaultValue={title }
                        />
                        <br />
                        <input
                            type="text"
                            name="url"
                            placeholder="Url"
                            onChange={e => setUrl(e.target.value) }
                            className="form-control"
                            defaultValue={url }
                        />
                        <br />
                        <button className="btn btn-primary">Add</button>
                    </form>
                </div>
            </div>
        </main>
    </div>
        )
}

export default AddBookmark;
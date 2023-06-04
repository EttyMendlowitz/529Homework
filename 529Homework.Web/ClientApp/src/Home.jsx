import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';

const Home = () => {

    const [bookmarks, setBookmarks] = useState([]);

    useEffect(() => {
        const getBookmarks = async () => {
            const { data } = await axios.get('/api/bookmarks/gettopbookmarks');
            setBookmarks(data);
        }
        getBookmarks();
    }, [])
    return (
        <div className="container" style={{ marginTop: 80 }}>
            <main role="main" className="pb-3">
                <div>
                    <h1>Welcome to the React Bookmark Application.</h1>
                    <h3>Top 5 most bookmarked links</h3>
                    <table className="table table-hover table-striped table-bordered">
                        <thead>
                            <tr>
                                <th>Url</th>
                                <th>Count</th>
                            </tr>
                        </thead>
                        <tbody>
                            {bookmarks.map(b => {
                                return <tr key={b.id}>
                                    <td>
                                        <a href='{b.url}' target='_blank'>{b.url}</a></td>
                                    <td>{b.count}</td>
                                </tr>
                            })}
                           
                        </tbody>
                    </table>
                </div>
            </main>
        </div>
    )

}

export default Home;
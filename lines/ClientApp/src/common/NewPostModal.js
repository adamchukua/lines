import React, { useState } from "react";

export default function NewPostModal() {
    const [isOpen, setIsOpen] = useState(false);
    const [postText, setPostText] = useState('');
    const [showSuccessNotification, setShowSuccessNotification] = useState(false);

    const openModal = () => setIsOpen(true);
    const closeModal = () => setIsOpen(false);

    const handlePostSubmit = (event) => {
        event.preventDefault();

        console.log(postText);

        setShowSuccessNotification(true);
        setTimeout(() => setShowSuccessNotification(false), 3000);

        closeModal();
    };

    return (
        <>
            <button className="btn" onClick={openModal}>New Post</button>

            <div className={`modal ${isOpen && "is-active"}`}>
                <div className="modal-background"></div>

                <div className="modal-card">
                    <header className="modal-card-head">
                        <p className="modal-card-title">New Post</p>
                        <button className="delete" aria-label="close" onClick={closeModal}></button>
                    </header>

                    <section className="modal-card-body">
                        <textarea
                            className="textarea"
                            placeholder="What's new?"
                            required
                            onChange={(event) => setPostText(event.target.value)}>
                        </textarea>
                    </section>

                    <footer className="modal-card-foot">
                        <button className="button is-success" onClick={handlePostSubmit}>Post</button>

                        <button className="button" onClick={closeModal}>Cancel</button>
                    </footer>
                </div>
            </div>

            {showSuccessNotification && (
                <div className="notification is-success is-light">
                    Post successful!
                </div>
            )}
        </>
    );
};
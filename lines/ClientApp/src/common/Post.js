export default function Post({ isThread, post }) {
    console.log(post);

    return (
        <>
            {post && (
                <article className="media">
                    <div className="media-left">
                        <figure className="image is-64x64">
                            <img src={post.user.avatar} className="is-rounded" alt="Image" />

                            {isThread && (<div className="thread-line"></div>)}
                        </figure>
                    </div>

                    <div className="media-content">
                        <div className="content">
                            <div className="is-flex is-justify-content-space-between">
                                <p>
                                    <strong>{post.user.name}</strong> <small>@{post.user.userName}</small>
                                </p>

                                <p>
                                    <small>31m</small>
                                </p>
                            </div>

                            <p>
                                {post.text}
                            </p>
                        </div>

                        <nav className="level is-mobile mt-5">
                            <div className="level-left">
                                <a className="level-item text-black" aria-label="reply">
                                    <span className="icon is-small">
                                        <i className="fas fa-reply" aria-hidden="true"></i>
                                    </span>

                                    <p className="ml-2">{post.replies.length}</p>
                                </a>

                                <a className="level-item text-black" aria-label="retweet">
                                    <span className="icon is-small">
                                        <i className="fas fa-retweet" aria-hidden="true"></i>
                                    </span>

                                    <p className="ml-2">{post.reposts.length}</p>
                                </a>

                                <a className="level-item text-black" aria-label="like">
                                    <span className="icon is-small">
                                        <i className="fas fa-heart" aria-hidden="true"></i>
                                    </span>

                                    <p className="ml-2">{post.likes.length}</p>
                                </a>

                                <a className="level-item text-black" aria-label="share">
                                    <span className="icon is-small">
                                        <i className="fas fa-share" aria-hidden="true"></i>
                                    </span>

                                    <p className="ml-2">0</p>
                                </a>
                            </div>
                        </nav>
                    </div>
                </article>
            )}
        </>
    );
}

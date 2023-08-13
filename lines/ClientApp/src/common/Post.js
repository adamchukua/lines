export default function Post({ isThread, post }) {
    const getHumanReadableTime = (datetime) => {
        const now = new Date();
        const timeDifference = now - datetime;

        const minute = 60 * 1000;
        const hour = 60 * minute;
        const day = 24 * hour;
        const week = 7 * day;
        const month = 30 * day;
        const year = 365 * day;

        if (timeDifference < minute) {
            return `${Math.floor(timeDifference / 1000)}s`;
        } else if (timeDifference < hour) {
            return `${Math.floor(timeDifference / minute)}m`;
        } else if (timeDifference < day) {
            return `${Math.floor(timeDifference / hour)}h`;
        } else if (timeDifference < week) {
            return `${Math.floor(timeDifference / day)}d`;
        } else if (timeDifference < month) {
            return `${Math.floor(timeDifference / week)}w`;
        } else if (timeDifference < year) {
            return `${Math.floor(timeDifference / month)}mo`;
        } else {
            return `${Math.floor(timeDifference / year)}y`;
        }
    };

    return (
        <>
            {post && (
                <article className="media">
                    <div className="media-left">
                        <figure className="image is-64x64">
                            <img src={`/images/avatars/${post.user.avatar}`} className="is-rounded" alt="Image" />

                            {isThread && (<div className="thread-line"></div>)}
                        </figure>
                    </div>

                    <div className="media-content">
                        <div className="content">
                            <div className="is-flex is-justify-content-space-between">
                                <a href={`profile/${post.user.userName}`}>
                                    <strong>{post.user.name}</strong> <small>@{post.user.userName}</small>
                                </a>

                                <p>
                                    <small>{getHumanReadableTime(new Date(post.createdAt))}</small>
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

                                    <p className="ml-2">{post.repliesCount}</p>
                                </a>

                                <a className="level-item text-black" aria-label="retweet">
                                    <span className="icon is-small">
                                        <i className="fas fa-retweet" aria-hidden="true"></i>
                                    </span>

                                    <p className="ml-2">{post.repostsCount}</p>
                                </a>

                                <a className="level-item text-black" aria-label="like">
                                    <span className="icon is-small">
                                        <i className="fas fa-heart" aria-hidden="true"></i>
                                    </span>

                                    <p className="ml-2">{post.likesCount}</p>
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

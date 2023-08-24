export default function User({ user }) {
    return (
        <>
            {user && (
                <article className="media">
                    <div className="media-left">
                        <figure className="image is-64x64">
                            <a href={`profile/${user?.userName}`}>
                                <img src={`/images/avatars/${user?.avatar}`} className="is-rounded" alt="Image" />
                            </a>
                        </figure>
                    </div>

                    <div className="media-content">
                        <div className="content">
                            <div className="is-flex is-justify-content-space-between">
                                <a href={`profile/${user?.userName}`}>
                                    <strong>{user?.name}</strong> <small>@{user?.userName}</small>
                                </a>
                            </div>

                            <a href={`profile/${user?.userName}`}>
                                {user?.description}
                            </a>
                        </div>
                    </div>
                </article>
            )}
        </>
    );
}

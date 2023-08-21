export default function SearchMenuItem({ user }) {
    return (
        <div className="box my-2">
            <a href={`profile/${user.userName}`}>
                <div className="is-flex is-flex-direction-row is-align-items-center">
                    <div className="mr-2">
                        <figure className="image is-32x32">
                            <img src={`/images/avatars/${user.avatar}`} alt="Image" className="is-rounded" />
                        </figure>
                    </div>

                    <div>
                        <p>
                            <strong>{user.name}</strong> <small>@{user.userName}</small>
                        </p>
                    </div>
                </div>
            </a>
        </div>
    );
}

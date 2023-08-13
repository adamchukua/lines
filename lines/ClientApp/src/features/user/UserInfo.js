export default function UserInfo({ user }) {
    return (
        <>
            <div className="profile-bg">
                <img src="https://bulma.io/images/placeholders/128x128.png" alt="" className="profile-bg--img" />
            </div>

            <section className="profile-data pl-3">
                <figure className="profile-avatar image is-64x64">
                    <img src={user.avatar} className="is-rounded profile-avatar--img" alt="Image" />
                </figure>

                <h3 className="title is-3 mb-2">{user.name}</h3>

                <p>@{user.userName}</p>

                <p className="my-2">
                    <span className="mr-2"><strong>{user.followersCount}</strong> followers</span>

                    <span className="mr-2"><strong>{user.followingCount}</strong> following</span>

                    <span><strong>{user.posts?.length}</strong> posts</span>
                </p>

                <p>{user.description}</p>
            </section>
        </>
    );
}

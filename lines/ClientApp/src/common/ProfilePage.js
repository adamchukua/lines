import PostsList from "../features/posts/PostsList"

export default function ProfilePage() {
    return (
        <>
            <div className="profile-bg">
                <img src="https://bulma.io/images/placeholders/128x128.png" alt="" className="profile-bg--img" />
            </div>

            <section className="profile-data pl-3">
                <figure className="profile-avatar image is-64x64">
                    <img src="https://bulma.io/images/placeholders/128x128.png" className="is-rounded profile-avatar--img" alt="Image" />
                </figure>

                <h3 className="title is-3 mb-2">Ivan Adamchuk</h3>

                <p>@adamchuk</p>

                <p className="my-2">
                    <span className="mr-2"><strong>7</strong> followers</span>

                    <span className="mr-2"><strong>28</strong> following</span>

                    <span><strong>18</strong> posts</span>
                </p>

                <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since</p>
            </section>

            <div class="tabs mb-0 mt-2">
                <ul>
                    <li class="is-active"><a>Posts</a></li>
                    <li><a>Replies</a></li>
                </ul>
            </div>

            <PostsList />
        </>
    );
}

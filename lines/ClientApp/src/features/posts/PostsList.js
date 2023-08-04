import Post from "../../common/Post";
import Thread from "../../common/Thread";

export default function PostsList() {
    return (
        <div>
            <div className="box post">
                <Post />
            </div>

            <div className="box post">
                <Thread />
            </div>

            <div className="box post">
                <Post />
            </div>
        </div>
    );
}

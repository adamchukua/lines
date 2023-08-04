import Post from "../../components/Post";
import Thread from "../../components/Thread";

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

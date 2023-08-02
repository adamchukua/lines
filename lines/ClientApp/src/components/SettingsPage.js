export default function SettingsPage() {
    return (
        <>
            <h3 className="title is-3">Settings</h3>

            <section>
                <h2 className="subtitle">Notifications</h2>
                <div className="field">
                    <input type="checkbox" id="likes" className="switch" checked />
                        <label for="likes">Likes</label>
                </div>
                <div className="field">
                    <input type="checkbox" id="replies" className="switch" checked />
                        <label for="replies">Replies</label>
                </div>
                <div className="field">
                    <input type="checkbox" id="newFollowers" className="switch" checked />
                        <label for="newFollowers">New Followers</label>
                </div>
            </section>

            <section className="mt-6">
                <h2 className="subtitle">Danger Zone</h2>
                <div className="field">
                    <p className="has-text-danger">Warning: Deleting your account is irreversible!</p>
                </div>
                <div className="field">
                    <button className="button is-danger" onclick="deleteAccount()">Delete Account</button>
                </div>
            </section>
        </>
    );
}

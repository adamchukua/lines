export default function Post() {
    return (
        <div className="box post">
            <article className="media">
                <div className="media-left">
                    <figure className="image is-64x64">
                        <img src="https://bulma.io/images/placeholders/128x128.png" className="is-rounded" alt="Image" />
                    </figure>
                </div>

                <div className="media-content">
                    <div className="content">
                        <div className="is-flex is-justify-content-space-between">
                            <p>
                                <strong>John Smith</strong> <small>@johnsmith</small>
                            </p>

                            <p>
                                <small>31m</small>
                            </p>
                        </div>

                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean efficitur sit amet massa fringilla egestas. Nullam condimentum luctus turpis.
                        </p>
                    </div>

                    <nav className="level is-mobile mt-5">
                        <div className="level-left">
                            <a className="level-item text-black" aria-label="reply">
                                <span className="icon is-small">
                                    <i className="fas fa-reply" aria-hidden="true"></i>
                                </span>

                                <p className="ml-2">0</p>
                            </a>

                            <a className="level-item text-black" aria-label="retweet">
                                <span className="icon is-small">
                                    <i className="fas fa-retweet" aria-hidden="true"></i>
                                </span>

                                <p className="ml-2">0</p>
                            </a>

                            <a className="level-item text-black" aria-label="like">
                                <span className="icon is-small">
                                    <i className="fas fa-heart" aria-hidden="true"></i>
                                </span>

                                <p className="ml-2">0</p>
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
        </div>
    );
}

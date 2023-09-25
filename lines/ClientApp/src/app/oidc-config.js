import { UserManager, WebStorageStateStore } from 'oidc-client';

const oidcConfig = {
    authority: 'https://localhost:7089',
    client_id: 'react',
    redirect_uri: "https://localhost:44484/callback",
    response_type: 'code',
    scope: 'openid profile Api',
    post_logout_redirect_uri: "https://localhost:44484",
    userStore: new WebStorageStateStore({ store: window.localStorage }),
};

const userManager = new UserManager(oidcConfig);

export default userManager;
import userManager from '../app/oidc-config';
import { useNavigate } from "react-router-dom";

export default function Callback() {
    const navigate = useNavigate();

    userManager.signinRedirectCallback(window.location.href).then(function (loggedUser) {
        window.location.href = "/";
    });
}
import { Form } from "react-bulma-components";

export default function SearchMenu() {
    const year = new Date().getFullYear();

    return (
        <section>
            <div className="search">
                <Form.Input placeholder="Search" rounded={true} className="has-text-centered" />
            </div>

            <p className="has-text-centered mt-5">&copy; {year} lines production</p>
        </section>
    );
}

import { Form } from "react-bulma-components";

export default function SearchMenu() {
    const year = new Date().getFullYear();

    return (
        <section className="pos-fix">
            <div className="search">
                <Form.Input placeholder="Search" rounded={true} className="has-text-centered" style={{ width: "278px" }} />
            </div>

            <p className="has-text-centered mt-5">&copy; {year} lines production</p>
        </section>
    );
}

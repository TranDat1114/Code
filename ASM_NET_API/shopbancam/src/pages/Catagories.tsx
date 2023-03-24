import axios from "axios";
import { useState, useEffect } from "react";

interface ICatagories {
    categoryId: number;
    categoryName: string;
    description: string;
    categoriesImg: string;
}
const listCatagory: ICatagories[] = [];
const Catagories = () => {
    const [catagories, setCatagories] = useState(listCatagory);

    useEffect(() => {
        axios
            .get<ICatagories[]>("https://localhost:7119/Home")
            .then((response) => setCatagories(response.data))
            .catch((error) => console.log(error));
    }, []);

    return (
        <>
            <p>Catagory</p>
            {catagories.map((p, index) => (
                <div>
                    <img
                        src={p.categoriesImg}
                        alt="img"
                        width={200}
                        height={200}
                    />
                    <p key={index}>
                        {p.categoryName} : {p.description}
                    </p>
                </div>
            ))}
        </>
    );
};

export default Catagories;

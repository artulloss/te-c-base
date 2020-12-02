

import axios from 'axios';

const http= axios.create({
    baseURL: "https://api.thecatapi.com/v1/images/search"
});

export default{
    getCat() {
        return http.get('');
    }
}
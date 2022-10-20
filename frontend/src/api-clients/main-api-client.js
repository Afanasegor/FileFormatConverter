import axios from "axios";

const baseDomain = "http://localhost:48850";
const baseURL = `${baseDomain}/api`;

const instance = axios.create({
  baseURL,
  mode: 'cors'
});

export default instance;
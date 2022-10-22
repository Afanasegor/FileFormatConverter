import axios from "axios";

const domain = process.env.VUE_APP_API_DOMAIN;
const port = process.env.VUE_APP_API_PORT;
const baseDomain = `http://${domain}:${port}`;
const baseURL = `${baseDomain}/api`;

const instance = axios.create({
  baseURL,
  mode: 'cors'
});

export default instance;
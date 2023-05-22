import { App } from 'vue';
import axios from 'axios';
import VueAxios from 'vue-axios';
import JwtService from '@/core/services/JwtService';
import { AxiosResponse, AxiosRequestConfig } from 'axios';
import store from '@/store';
import { Actions } from '@/store/enums/StoreEnums';

/**
 * @description service to call HTTP request via Axios
 */
class ApiService {
  /**
   * @description property to share vue instance
   */
  public static vueInstance: App;

  /**
   * @description initialize vue axios
   */
  public static init(app: App<Element>) {
    ApiService.vueInstance = app;
    ApiService.vueInstance.use(VueAxios, axios);

    ApiService.vueInstance.axios.defaults.baseURL = process.env.VUE_APP_API_URL;
  }

  /**
   * @description set the default HTTP request headers
   */
  public static setHeader(): void {
    ApiService.vueInstance.axios.defaults.headers['Authorization'] = 'Bearer ' + JwtService.getToken();
    ApiService.vueInstance.axios.defaults.headers['Accept'] = 'application/json';
  }

  /**
   * @description send the GET HTTP request
   * @param resource: string
   * @param params: AxiosRequestConfig
   * @returns Promise<AxiosResponse>
   */
  public static async query(resource: string, params: AxiosRequestConfig): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.get(resource, params);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }

  /**
   * @description send the GET HTTP request
   * @param resource: string
   * @param slug: string
   * @returns Promise<AxiosResponse>
   */
  public static async get(resource: string, slug = '' as string): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.get(`${resource}/${slug}`);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }

  public static async getWithParamUrl(resource: string, slug = '' as string): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.get(`${resource}`);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }

  /**
   * @description set the POST HTTP request
   * @param resource: string
   * @param params: AxiosRequestConfig
   * @returns Promise<AxiosResponse>
   */
  public static async post(resource: string, params: AxiosRequestConfig): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.post(`${resource}`, params);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }

  /**
   * @description send the UPDATE HTTP request
   * @param resource: string
   * @param slug: string
   * @param params: AxiosRequestConfig
   * @returns Promise<AxiosResponse>
   */
  public static async update(resource: string, slug: string, params: AxiosRequestConfig): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.put(`${resource}/${slug}`, params);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }

  /**
   * @description Send the PUT HTTP request
   * @param resource: string
   * @param params: AxiosRequestConfig
   * @returns Promise<AxiosResponse>
   */
  public static async put(resource: string, params: AxiosRequestConfig): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.put(`${resource}`, params);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }

  /**
   * @description Send the DELETE HTTP request
   * @param resource: string
   * @returns Promise<AxiosResponse>
   */
  public static async delete(resource: string): Promise<AxiosResponse> {
    store.dispatch(Actions.ADD_BODY_LOADING);
    var result = await ApiService.vueInstance.axios.delete(resource);
    store.dispatch(Actions.REMOVE_BODY_LOADING);
    return result;
  }
}

export default ApiService;

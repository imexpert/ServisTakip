import { Actions, Mutations } from "@/store/enums/StoreEnums";
import * as signalR from "@microsoft/signalr";
import store from "./../../store";
import router from "./../../router";

class SignalRService {
    public static connection: signalR.HubConnection;

    public static init() {
        // Create your connection
        SignalRService.connection = new signalR.HubConnectionBuilder()
            .withUrl(process.env.VUE_APP_HUB_URL)
            .withAutomaticReconnect([
                0,
                2000,
                3000,
                3000,
            ])
            .build();
    }

    public static connect() {
        SignalRService.connection.start().catch(function (err) {
            console.log(err);
        });
    }

    public static create() {
        SignalRService.connection.on("RefreshPage", (e) => {
            console.log("RefreshPage");
            window.location.href = "/";
        });

        SignalRService.connection.on("CloseSession", async (e) => {
            console.log("CloseSession");
            await store.dispatch(Actions.LOGOUT);
        });
    }
}

export default SignalRService;
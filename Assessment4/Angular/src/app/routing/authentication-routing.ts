export const AUTHENTICATION_ROUTES = [
    { path: '', loadChildren: () => import("../authentication/authentication.module").then(x => x.AuthenticationModule) }
];
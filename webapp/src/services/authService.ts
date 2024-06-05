import { BASE_API_URL } from "../Constants";
import { AccessTokenResponse } from "../types/AccessTokenResponse";
import { LoginRequest } from "../types/LoginRequest";

const URL: string = `${BASE_API_URL}/auth`;
const DEFAULT_HEADERS: Record<string, string> = {
  "Content-Type": "application/json",
};

export const login = async (
  credentials: LoginRequest
): Promise<AccessTokenResponse> => {
  return await fetch(`${URL}/login`, {
    headers: DEFAULT_HEADERS,
    method: "POST",
    body: JSON.stringify(credentials),
  }).then((response) => {
    if (response.ok) return response.json();

    throw new Error("Invalid credentials");
  });
};

import { AccessTokenResponse } from "../types/AccessTokenResponse";
import { LoginRequest } from "../types/LoginRequest";

const URL: string = "http://localhost:5111/api/auth";
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

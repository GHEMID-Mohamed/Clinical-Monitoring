import config from "../config.json";

type Clinic = {
  id: string;
  name: string;
  address: string;
};

const getClinics = async () => {
  const response = await fetch(`/api/clinics`, {
    headers: config.headers,
  });

  if (response.ok) {
    return (await response.json()) as Promise<Clinic[]>;
  }
};

export { getClinics };

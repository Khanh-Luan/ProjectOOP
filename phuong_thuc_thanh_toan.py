from abc import ABC, abstractmethod


class PhuongThucThanhToan(ABC):
    @abstractmethod
    def XuLyThanhToan(self, soTien):
        pass
